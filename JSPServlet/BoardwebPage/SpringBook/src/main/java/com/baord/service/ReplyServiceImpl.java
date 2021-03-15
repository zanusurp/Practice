package com.baord.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.board.domain.Criteria;
import com.board.domain.ReplyPageDTO;
import com.board.domain.ReplyVO;
import com.board.mapper.BoardMapper;
import com.board.mapper.ReplyMapper;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@Service
@Log4j
public class ReplyServiceImpl implements ReplyService{
	
	@Setter(onMethod_=@Autowired)
	private ReplyMapper mapper;
	
	@Setter(onMethod_=@Autowired)
	private BoardMapper boardMapper;
	
	@Transactional
	@Override
	public int register(ReplyVO vo) {
		log.info("register ================================================================="+vo);
		boardMapper.updateReplyCnt(vo.getBno(), 1); //하나씩 넣기로
		return mapper.insert(vo);
		
	}

	@Override
	public ReplyVO get(Long rno) {
		log.info(rno+"get =================================================================");
		
		return mapper.read(rno);
	}

	@Override
	public int modify(ReplyVO vo) {
		log.info("modify =================================================================");
		
		return mapper.update(vo);
		
	}

	@Override
	public int remove(Long rno) {
		log.info(rno+"remove =================================================================");
		ReplyVO vo = mapper.read(rno);
		boardMapper.updateReplyCnt(vo.getBno(), -1);
		return mapper.delete(rno);
	}

	@Override
	public List<ReplyVO> getList(Criteria cri, Long bno) {
		log.info("getList "+bno+"================================================================= ");
		
		return mapper.getListWithPaging(cri, bno);
	}

	@Override
	public ReplyPageDTO getListPage(Criteria cri, Long bno) {
		return new ReplyPageDTO(mapper.getCountByBno(bno),mapper.getListWithPaging(cri, bno));
	}

}
