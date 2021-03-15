package com.board.service;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.baord.service.SampleService;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@RunWith(SpringJUnit4ClassRunner.class)
@Log4j
@ContextConfiguration({"file:src/main/webapp/WEB-INF/spring/root-context.xml"})
public class SampleServiceTests {
	@Setter(onMethod_=@Autowired)
	private SampleService service;
	
	@Test
	public void testClass() {
		log.info("서비스만"+service);
		log.info("서비스 네임만:"+service.getClass().getName());
		
	}
	@Test
	public void testAdd() throws Exception{
		log.info("두에드 : "+service.doAdd("11", "22"));
	}
//	@Test //기가찬다 에러나버림
//	public void testAddError() throws Exception{
//		log.info("덧셈 알파뱃으로 시도 : "+service.doAdd("123", "ADDD"));
//	}
}
