package com.test.board.controller;

import java.io.IOException;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.test.board.controller.action.Action;
import com.test.dao.BoardDAO;
import com.test.dto.BoardVO;

public class BoarcListAction implements Action{

	@Override
	public void execute(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String url =  "/board/boardList.jsp";
		
		BoardDAO bDao = BoardDAO.getInstance();
		List<BoardVO> boardList = bDao.selectAllBoard();
		request.setAttribute("boardList", boardList);
		RequestDispatcher dispatcher = request.getRequestDispatcher(url);
		dispatcher.forward(request, response);
		
	}

}
