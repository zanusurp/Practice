package com.test.board.controller;

import com.test.board.controller.action.Action;

public class ActionFactory {
	private static ActionFactory instance = new ActionFactory();
	private ActionFactory() {
		super();
	}
	public static ActionFactory getinstance() {
		return instance;
	}
	public Action getAction(String command) {
		Action action = null;
		System.out.println("ActionFactory : "+command);
		if(command.equals("board_list")) {
			action =  new BoarcListAction();
		}
		if(command.equals("board_write_form")) {
			action = new WriteFormAction();
		}
		if(command.equals("board_write")) {
			action = new BoardWriteAction();
		}
		
		return action;
		
		
	}
}
