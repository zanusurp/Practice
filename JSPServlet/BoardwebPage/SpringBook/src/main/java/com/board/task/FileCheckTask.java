package com.board.task;

import java.io.Console;
import java.io.File;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import com.board.domain.BoardAttachVO;
import com.board.mapper.BoardAttachMapper;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

@Log4j
@Component
public class FileCheckTask {
	
	@Setter(onMethod_=@Autowired)
	private BoardAttachMapper attachMapper;
	
	private String getFolderYesterDay() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
		Calendar cal = Calendar.getInstance();
		log.info("===========현재 시간  millis 득: "+ cal.getTimeInMillis());
		cal.add(Calendar.DATE, -1);
		String str = sdf.format(cal.getTime());
		log.info("============캘랜더 시간 얻기  : cal.getTime :"+str);
		return str.replace("-", File.separator);
		
	}
	
	@Scheduled(cron = "0 0 2 * * *") //초, 분, 시, 일, 월, 요일,(년) : 2시간마다 체크
	public void checkFiles() throws Exception{
		log.warn("File Check Task run ==================================");
		log.warn(new Date());
		//디비에 있는 것 리스트로
		List<BoardAttachVO> fileList = attachMapper.getOldFiles();
		//리비 리스트 디렉토리 체크
		List<Path> fileListPaths = fileList.stream()
				.map(vo->Paths.get("c:\\upload", vo.getUploadPath(),"s_"+vo.getUuid()+"_"+vo.getFileName()))
				.collect(Collectors.toList());
		//이미지 섬네일 확인
		fileList.stream().filter(vo -> vo.isFileType() == true) //있니?
		.map(vo -> Paths.get("c:\\upload",vo.getUploadPath(),"s_"+vo.getUuid()+"_"+vo.getFileName()))
		.forEach(p->fileListPaths.add(p));//있으면 추가 시킴
		log.info("=====================================");
		fileListPaths.forEach( file -> log.warn("파일 이름들  : "+file));
		//어제 파일
		File targetDir = Paths.get("c:\\upload",getFolderYesterDay()).toFile();
		File[] removeFiles = targetDir.listFiles(file -> fileListPaths.contains(file.toPath())==false);
		log.warn("----------------------");
		for(File file:removeFiles) {
			log.warn("지울 파일들  : "+file.getAbsolutePath());
			file.delete();
			log.info("파일 삭제 완료 ");
		}
		
	}
}
