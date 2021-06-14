package com.board.controller;

import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import lombok.extern.log4j.Log4j;

@Log4j
@Controller
public class CommonController {
	@GetMapping("/accessError")
	public void accessError(Authentication auth, Model model) {
		log.info("============== 접근 제한 : "+auth);
		model.addAttribute("msg","공용 제어  : 접근 할 수 없습니다.");

	}
	@GetMapping("/customLogin")
	public void loginInput(String error, String logout, Model model) {
		log.info("로긴 창 ==========================");
		log.info("error 에러 ========: "+error);
		log.info("로그 아웃 =================="+logout);
		
		if(error!=null) {
			model.addAttribute("error","계정 확인 하세요 로그인 에러 ");
		}
		if(logout != null) {
			model.addAttribute("logout","로그아웃!");
		}
	}
	@GetMapping("/customLogout")
	public void logoutGet() {
		log.info("코먼 컨트롤러 = ===============================custom logout");
	}
}