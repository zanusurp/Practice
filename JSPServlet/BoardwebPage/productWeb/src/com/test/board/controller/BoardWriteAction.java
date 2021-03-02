package com.test.board.controller;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.test.board.controller.action.Action;
import com.test.dao.BoardDAO;
import com.test.dto.BoardVO;

public class BoardWriteAction implements Action{

	@Override
	public void execute(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		BoardVO bVo  = new BoardVO();
		bVo.setName(request.getParameter("name"));
		bVo.setPass(request.getParameter("pass"));
		bVo.setEmail(request.getParameter("email"));
		bVo.setTitle(request.getParameter("title"));
		bVo.setContent(request.getParameter("content"));
		
		BoardDAO bDoa = BoardDAO.getInstance();
		bDoa.insertBoard(bVo);
		
		new BoarcListAction().execute(request, response);
		
	}

}
