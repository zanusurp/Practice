package com.book.persistence;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.book.mapper.TimeMapper;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
@Log4j
public class TimeMapperTest {
	@Setter(onMethod_= @Autowired)
	private TimeMapper timeMapper;
	
	@Test
	public void testGetTime() {
		log.info("===========================================");
		log.info("testGEtTime 1 ");
		log.info("클래스 이름  :  "+timeMapper.getClass().getName());
		log.info(timeMapper.getTime());
		log.info("===========================================");
	}
	@Test
	public void testGetTime2() {
		log.info("===========================================");
		log.info("testGEtTime 2 ");
		log.info(timeMapper.getTime2());
		log.info("===========================================");
	}
}
