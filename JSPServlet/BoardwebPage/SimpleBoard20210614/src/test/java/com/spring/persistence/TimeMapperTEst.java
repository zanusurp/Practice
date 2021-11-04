package com.spring.persistence;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.spring.mapper.TimeMapper;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
@Log4j
public class TimeMapperTEst {
	@Setter(onMethod_= {@Autowired})
	private TimeMapper timeMapper;
	
	@Test
	public void testGetTime() {
		log.info("글라스 불러왔나 : "+timeMapper.getClass().getName());
		log.info("디비상 듀얼로 몇시냐? "+timeMapper.getTime());
	}
	@Test
	public void testGetTime2() {
		log.info("글라스 불러왔나 : "+timeMapper.getClass().getName());
		log.info("2번째 디비상 듀얼로 몇시냐? "+timeMapper.getTime2());
	}
}
