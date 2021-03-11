package com.baord.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.board.domain.BoardVO;
import com.board.domain.Criteria;
import com.board.mapper.BoardMapper;

import lombok.AllArgsConstructor;
import lombok.Setter;
import lombok.extern.log4j.Log4j;

@Service
@Log4j
@AllArgsConstructor
public class BoardServiceImpl implements BoardService{

	@Setter(onMethod_=@Autowired)//4버젼 이후로 자동처리 된다고는 하지만 오류대비
	private BoardMapper mapper;
	
	@Override
	public void register(BoardVO board) {
		log.info("==============register 글 넣기 : "+board);
		mapper.insertSelectKey(board);
		
	}

	@Override
	public BoardVO get(Long bno) {
		log.info("============get 읽어올 게시글 번호 : "+bno);
		return mapper.read(bno);
	}

	@Override
	public boolean modify(BoardVO board) {
		log.info("===========modify 게시글 수정 : "+board);
		return mapper.update(board) == 1;
	}

	@Override
	public boolean remove(Long bno) {
		log.info("===========remove 게시글 삭제  : "+bno);
		return mapper.delete(bno) == 1;
	}

//	@Override //페이징 없는 것
//	public List<BoardVO> getList() {
//		log.info("================getList게시글 전체 목록 읽어오기  ");
//		return mapper.getList();
//		
//	}

	@Override
	public List<BoardVO> getList(Criteria cri) { //페이징 있는 것
		log.info("===========getList페이징 게시글 목록: "+cri.getPageNum()+"페이지양 : "+cri.getAmount());
		
		return mapper.getListWithPaging(cri);
	}

	@Override
	public int getTotal(Criteria cri) {
		log.info("get Total Count ==========================================");
		return mapper.getTotalCount(cri);
	}

}
