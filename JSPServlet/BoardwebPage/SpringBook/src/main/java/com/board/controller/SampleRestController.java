package com.board.controller;

import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.board.domain.RestTicket;
import com.board.domain.SampleRestVO;

import lombok.extern.log4j.Log4j;

@RestController
@RequestMapping("/sample")
@Log4j
public class SampleRestController {
	
	@GetMapping(value = "/getText", produces = "text/plain;charset=UTF-8")
	public String getText() {
		log.info("Mime tpye : "+ MediaType.TEXT_PLAIN_VALUE);
		return "안녕하세요";
		
	}
	@GetMapping(value = "/getSample", produces = {MediaType.APPLICATION_JSON_UTF8_VALUE, MediaType.APPLICATION_XML_VALUE})
	public SampleRestVO getSample() {
		return new SampleRestVO(112,"스타","f로그");
	}
	@GetMapping(value = "/getList")
	public List<SampleRestVO> getList(){
		return IntStream.range(1, 10).mapToObj(i-> new SampleRestVO(i,i+"first",i+"last")).collect(Collectors.toList());
	}
	@GetMapping(value = "/check", params = {"height","weight"})
	public ResponseEntity<SampleRestVO> check(Double height, Double weight){
		SampleRestVO vo = new SampleRestVO(0,""+height,""+weight);
		ResponseEntity<SampleRestVO> result = null;
		
		if(height < 150) {
			result = ResponseEntity.status(HttpStatus.BAD_GATEWAY).body(vo);
			
		}else {
			result = ResponseEntity.status(HttpStatus.OK).body(vo);
		}
		return result;
	}
	@GetMapping("/product/{cat}/{pid}")
	public String[] getPath(@PathVariable("cat") String cat, @PathVariable("pid") Integer pid) {
		return new String[] {"category: " +cat, "productId : "+ pid};
	}
	@PostMapping("/ticket")
	public RestTicket convert(@RequestBody RestTicket ticket) {
		log.info("convert Restticket :" + ticket);
		return ticket;
	}
}
