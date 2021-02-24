package com.test.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import com.test.dto.BoardDTO;

import util.DBManager;

public class BoardDAO {
	private BoardDAO() {}
	private static BoardDAO instance = new BoardDAO();
	public static BoardDAO getInstance () {
		return instance;
	}
	
	public List<BoardDTO> selectAllList(int pageno){
		System.out.println("게시판으로 넘어온 페이지 : " + pageno); //boardListAction
		String sql = "select X.* "
				+ "from ( select rownum as rnum, "
				+ " A.* from (select * from board order by num desc) A"
				+ " where rownum <= ?) X "
				+ "where X.rnum >=?";
		
		List<BoardDTO> list = new ArrayList<BoardDTO>();
		Connection conn = null;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		
		try {
			conn = DBManager.getConnection();
			
		} 
		catch (Exception e) {
			// TODO: handle exception
		}
		finally {
			
		}
		
	}
	
	
	
}
