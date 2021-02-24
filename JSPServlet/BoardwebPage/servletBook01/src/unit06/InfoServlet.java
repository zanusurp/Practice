package unit06;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


@WebServlet("/InfoServlet")
public class InfoServlet extends HttpServlet {
	protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException{
		res.setContentType("text/html; charset=UTF-8");
		String name = req.getParameter("name");
		String addr = req.getParameter("addr");
		
		PrintWriter out = res.getWriter();
		out.print("<html><body>");
		out.print("이볅한 정보 <br>");
		out.print("이볅한 정보 <br>");
		out.print("이름 : "+name);
		out.print("wㅜ소: "+addr);
		out.print("</body></html>");
		
	}
	@Override
	protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		// TODO Auto-generated method stub
		req.setCharacterEncoding("UTF-8");
		doGet(req, resp);
	}
}
