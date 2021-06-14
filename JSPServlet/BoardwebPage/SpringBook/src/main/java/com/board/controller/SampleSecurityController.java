package com.board.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

import lombok.extern.log4j.Log4j;

@Log4j
@RequestMapping("/sample/*")
@Controller
public class SampleSecurityController {
	@GetMapping("/allSecurity")
	public String allSecurity() {
		log.info("아무나 접근 할 수 있습니다.");
		return "sample/allSecurity";
		
	}
	@GetMapping("/memberSecurity")
	public String memberSecurity() {
		log.info("로그인 사용자만 들어올 수 있습니다.");
		return "sample/memberSecurity";
	}
	
	@GetMapping("/adminSecurity")
	public void adminSecurity() {
		log.info("관리자만 들어올 수 있습니다.");
	}
	
}
