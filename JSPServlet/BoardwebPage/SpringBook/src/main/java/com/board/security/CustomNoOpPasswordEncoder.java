package com.board.security;

import org.springframework.security.crypto.password.PasswordEncoder;

import lombok.extern.log4j.Log4j;

@Log4j
public class CustomNoOpPasswordEncoder implements PasswordEncoder{@Override
	public String encode(CharSequence rawPassword) {
		log.warn("인코딩 되기 전 비밀번호  : =============before encode : "+rawPassword);
		return rawPassword.toString();
	}

	@Override
	public boolean matches(CharSequence rawPassword, String encodedPassword) {
		log.warn("비밀번호 매칭  : 생 문자 = "+ rawPassword + ": 인코드된 문자 = " + encodedPassword);
		return rawPassword.toString().equals(encodedPassword.toString());
	}
	
}
