package com.board.service;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.baord.service.SampleTXService;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
@Log4j
public class SampleTXServiceTests {
	@Setter(onMethod_=@Autowired)
	private SampleTXService service;
	
	@Test
	public void testLong() {
		String str = "Starry\r\n"+
					"Starry night\r\n" + "paint YOur pallette blue and grey \r\n"+"look out onea summer's day";
		log.info("바이트 길이 : "+str.getBytes().length);
		log.info("일반 랭기로 확인 : "+str.length());
		service.addData(str);
	}
	
}
