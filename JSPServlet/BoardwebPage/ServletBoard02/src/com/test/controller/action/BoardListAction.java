package com.test.controller.action;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.test.controller.Action;


public class BoardListAction implements Action{

	@Override
	public void execute(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		int pageno=0;
		if(req.getParameter("pageno")!=null) {
			pageno=Integer.parseInt(req.getParameter("pageno"));
			System.out.println("현재 페이지 넘버 : "+pageno);
		}else {
			pageno=1;
		}
		String url = "/board/boardList.jsp";
		
	}
	

}
