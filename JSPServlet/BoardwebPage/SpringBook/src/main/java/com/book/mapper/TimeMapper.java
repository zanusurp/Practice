package com.book.mapper;

import org.apache.ibatis.annotations.Select;

public interface TimeMapper {
	@Select("select sysdate from dual")
	public String getTime();
	
	public String getTime2(); //얘는 xml을 통해 확인될 것임 
}
