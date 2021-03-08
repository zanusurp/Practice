package com.board.service;

import static org.junit.Assert.assertNotNull;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.baord.service.BoardService;
import com.board.domain.BoardVO;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@RunWith(SpringJUnit4ClassRunner.class)
@Log4j
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
public class BoardServiceTest {
	@Setter(onMethod_=@Autowired)
	private BoardService service;
	
	@Test
	public void testExist() {
		log.info(service);
		assertNotNull(service);
	}
	@Test
	public void testRegister() {
		BoardVO board = new BoardVO();
		board.setTitle("서비스 모드로 제목");
		board.setContent("서비스모드로 내용전달");
		board.setWriter("Newbie");
		service.register(board);
		
		log.info("생선된 게시물의 번호 : " + board.getBno());
	}
	@Test
	public void testGetList() {
		service.getList().forEach(board->log.info(board));
	}
	@Test
	public void getTest() {
		 log.info(service.get(5L));
	}
	
//	@Test //이제 없으므로
//	public void testDelete() {
//		log.info("remove result = "+service.remove(11L));
//		
//	}
	@Test
	public void testUpdate() {
		BoardVO board = service.get(3L);
		if(board ==null) {
			return;
		}
		board.setTitle("서비스 수정한 제목 임");
		board.setContent("실상 수정되는 것은  제목과 내용 수정 날짜는 알아서 바뀝니다.");
		log.info("modified result : "+service.modify(board));
	}
	
}
