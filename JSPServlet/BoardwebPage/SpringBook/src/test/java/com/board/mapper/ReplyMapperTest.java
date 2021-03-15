package com.board.mapper;

import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.board.domain.Criteria;
import com.board.domain.ReplyVO;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
@Log4j
public class ReplyMapperTest {
	
	private Long[] bnoArr = {31759L, 31758L, 31757L, 31756L, 31755L};
	
	@Setter(onMethod_=@Autowired)
	private ReplyMapper mapper;
	
//	@Test
//	public void testCreate() {
//		log.info("=testcreate===========================================================");
//		IntStream.rangeClosed(1, 10).forEach(i->{
//			ReplyVO vo = new ReplyVO();
//			vo.setBno(bnoArr[i%5]);
//			vo.setReply("댓글을 적어둡니다"+i);
//			vo.setReplyer("replyer"+i);
//			
//			mapper.insert(vo);
//		});
//		
//		log.info("=testcreate===========================================================");
//	}
	@Test
	public void testMapper() {
		log.info("=testMapperExist======================================================");
		log.info(mapper);
	}
	@Test
	public void testREad() {
		log.info("=tesREad=====================================================");
		Long targetRe = 5L;
		ReplyVO vo = mapper.read(targetRe);
		log.info(vo);
		
		log.info("=tesRead======================================================");
	}
	@Test
	public void delete() {
		log.info("====================delete===================================");
		Long rno = 3L;
		mapper.delete(rno);
		
		log.info("====================delete===================================");
	}
	@Test
	public void update() {
		log.info("============update-=========================================");
		Long rno = 5L;
		ReplyVO vo = mapper.read(rno);
		vo.setReply("테스트로 수정된 댓글 입니다.");
		int count = mapper.update(vo);
		log.info(count);
		log.info("============update-=========================================");
	}
//	@Test
//	public void testList() {
//		log.info("========================================list ");
//		Criteria cri = new Criteria();
//		List<ReplyVO> replies = mapper.getListWithPaging(cri, bnoArr[0]);
//		replies.forEach(reply -> log.info(reply));
//		log.info("========================================list ");
//	}
	@Test
	public void testList2() {
		Criteria cri  = new Criteria(2,10);
		List<ReplyVO> replies = mapper.getListWithPaging(cri, 31759L);
		replies.forEach(reply-> log.info(reply));
	}
	
}
