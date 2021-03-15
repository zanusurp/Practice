package com.baord.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.board.mapper.SampleMapper1;
import com.board.mapper.SampleMapper2;

import lombok.Setter;
import lombok.extern.log4j.Log4j;


@Service
@Log4j
public class SampleTXServiceImpl implements SampleTXService{

	@Setter(onMethod_=@Autowired)
	private SampleMapper1 mapper1;
	
	@Setter(onMethod_=@Autowired)
	private SampleMapper2 mapper2;
	
	@Transactional
	@Override
	public void addData(String value) {
		log.info("매퍼 1 =======================================");
		mapper1.insertCol1(value);
		
		log.info("매퍼 2 =======================================");
		mapper2.insertCol1(value);
		
		log.info("끝==================================================");
	}
	
}
