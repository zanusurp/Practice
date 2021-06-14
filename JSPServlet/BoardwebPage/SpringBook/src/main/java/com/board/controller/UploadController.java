package com.board.controller;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.URLDecoder;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

import org.springframework.core.io.FileSystemResource;
import org.springframework.core.io.Resource;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.util.FileCopyUtils;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;

import com.board.domain.AttachFileDTO;

import lombok.extern.log4j.Log4j;
import net.coobird.thumbnailator.Thumbnailator;

@Controller
@Log4j
public class UploadController {//스프링 레가시 mvc
	
	private boolean checkImageType(File file) {
		try {
			String contentType = Files.probeContentType(file.toPath());	
			return contentType.startsWith("image");
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return false;
	}
	
	private String getFolder() {
		log.info("오늘 날짜로 알아 보고 폴더 만들기 시작");
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
		Date date = new Date();
		
		String str = sdf.format(date);
		return str.replace("-", File.separator);
	}
	
	@GetMapping("/uploadForm")
	public void uploadForm() {
		log.info("업로드 폼 ");
	}
	@PostMapping("/uploadFormAction")
	public void uploadFormPost(MultipartFile[] uploadFile, Model model) {
		
		String uploadFolder = "c:\\upload";
		for(MultipartFile multipartFile : uploadFile) {
			log.info("옵로드중-----------------------------------------");
			log.info("uploadfile 이름 : "+multipartFile.getOriginalFilename());
			log.info("uploadfile 크기 : "+multipartFile.getSize());
			
			File saveFile = new File(uploadFolder,multipartFile.getOriginalFilename());
			
			try {
				multipartFile.transferTo(saveFile);
			} catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
			}
		}
	}
	@GetMapping("/uploadAjax")
	public void uploadAjax() {
		log.info("upload ajax");
	}
	@PostMapping("/uploadAjaxAction")
	public void uploadAjaxPost(MultipartFile[] uploadFile) {
		log.info("upload ajax post.  . . . . ");
		String uploadFolder = "c:\\upload";
		//폴더형성
		File uploadPath = new File(uploadFolder, getFolder());
		log.info("업로드 경로 : "+uploadPath);
		
		if(uploadPath.exists()==false) {
			uploadPath.mkdirs();
		}
		
		for(MultipartFile multipartFile : uploadFile) {
			log.info("Update==================================================================");
			log.info("업로드 파일 이름"+multipartFile.getOriginalFilename());
			log.info("파일 사이즈 : "+multipartFile.getSize());
			String uploadFileName= multipartFile.getOriginalFilename();
			
			uploadFileName = uploadFileName.substring(uploadFileName.lastIndexOf("\\")+1);
			log.info("파일 이름만" +uploadFileName);
			
			UUID uuid = UUID.randomUUID();
			uploadFileName = uuid.toString() + "_" + uploadFileName;
			
			try {
				File saveFile = new File(uploadPath,uploadFileName);
				multipartFile.transferTo(saveFile);
				
				if(checkImageType(saveFile)) {
					FileOutputStream thumbnail = new FileOutputStream(new File(uploadPath,"s_"+uploadFileName));
					Thumbnailator.createThumbnail(multipartFile.getInputStream(),thumbnail,100,100);
					thumbnail.close();
				}				
			} catch (Exception e) {
				log.error(e.getMessage());
			}
			
		}
		
	}
	//이미지에 대한 구분도 있어서 이게 더 좋음
	@PostMapping(value = "/uploadAjaxAction2", produces = {MediaType.APPLICATION_JSON_UTF8_VALUE})
	@ResponseBody
	public ResponseEntity<List<AttachFileDTO>> uploadAjaxPost2(MultipartFile[] uploadFile){
		List<AttachFileDTO> list = new ArrayList<>();
		String uploadFolder = "c:\\upload";
		
		String uploadFolderPath = getFolder(); //날짜로 폴더화 이게 제일 나음
		File uploadPath = new File(uploadFolder, uploadFolderPath);
		log.info("파일 경로"+uploadPath);
		if(uploadPath.exists()==false) {
			uploadPath.mkdirs();
			log.info("경로는 만들어졌음");
		}
		log.info("경로는 이미 만들어졌으므로 다음 진행");
		for (MultipartFile multipartFile : uploadFile) {
			log.info("파일 입력 시작.................................");
			AttachFileDTO attachDTO = new AttachFileDTO();
			log.info("파일 이름 추출 부분 초기 접근하나");
			String uploadFileName = multipartFile.getOriginalFilename();
			log.info("파일 원래 이름 :  "+uploadFileName);
			uploadFileName = uploadFileName.substring(uploadFileName.lastIndexOf("\\")+1);
			log.info("섭스트링 후 업로드 파일 이름 : "+uploadFileName);
			attachDTO.setFileName(uploadFileName);
			UUID uuid = UUID.randomUUID(); //개인적으론 시치분 생각하지만 그것마저도 중복위험있으니 
			
			uploadFileName = uuid.toString()+"_"+uploadFileName;
			
			try {
				File saveFile = new File(uploadPath,uploadFileName);
				log.info(saveFile);
				multipartFile.transferTo(saveFile);
				attachDTO.setUuid(uuid.toString());
				attachDTO.setUploadPath(uploadFolderPath);
				
				if(checkImageType(saveFile)) {
					attachDTO.setImage(true);
					FileOutputStream thumbnail = new FileOutputStream(new File(uploadPath,"s_"+uploadFileName));
					Thumbnailator.createThumbnail(multipartFile.getInputStream(),thumbnail,100,100);
					thumbnail.close();
				}
				list.add(attachDTO);
				
			}catch (Exception e) {
				e.printStackTrace();
			}
			
			
		}
		return new ResponseEntity<>(list, HttpStatus.OK);
		
		
	}
	@GetMapping("/display")
	@ResponseBody
	public ResponseEntity<byte[]> getFile(String fileName){
		log.info("디스플레이할 파일 일이름 : " + fileName);
		File file = new File("c:\\upload\\"+fileName);
		log.info("디스플레이할 파일 서버에서 불러오는것 확인 : file : "+ file);
		ResponseEntity<byte[]> result = null;
		
		try {
			HttpHeaders header  = new HttpHeaders();
			header.add("Content-Type", Files.probeContentType(file.toPath()));
			result = new ResponseEntity<>(FileCopyUtils.copyToByteArray(file),header,HttpStatus.OK);
			
		} catch (IOException e) {
			e.printStackTrace();
		}
		return result;
	}
	//다운로드 파일
	@GetMapping(value = "/download", produces = {MediaType.APPLICATION_OCTET_STREAM_VALUE})
	@ResponseBody
	public ResponseEntity<Resource> donwloadFile(String fileName){
		log.info("다운로드 팡릴  : "+fileName);
		Resource resource = new FileSystemResource("c:\\upload\\"+fileName);
		log.info("리소스  ; "+resource);
		String resourceName = resource.getFilename();
		HttpHeaders headers = new HttpHeaders();
		try {
			headers.add("Content-Disposition","attachment;filename="+ new String(resourceName.getBytes("UTF-8"),"ISO-8859-1"));
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return new ResponseEntity<Resource>(resource,headers,HttpStatus.OK);
	}
	//다운로드 ie 처리 추가 
	@GetMapping(value = "/download2", produces = {MediaType.APPLICATION_OCTET_STREAM_VALUE})
	@ResponseBody
	public ResponseEntity<Resource> donwloadFile2(@RequestHeader("User-Agent") String userAgent ,String fileName){
		log.info("다운로드 팡릴  : "+fileName);
		Resource resource = new FileSystemResource("c:\\upload\\"+fileName);
		log.info("리소스  ; "+resource);
		
		if(resource.exists() == false) {
			return new ResponseEntity<>(HttpStatus.NOT_FOUND);
		}
				
		String resourceName = resource.getFilename();
		log.info("파일 이름 : "+ resourceName);
		
		String resourceOriginalName = resourceName.substring(resourceName.indexOf("_")+1);
		log.info("파일 원래 이름 갖고 오기" + resourceOriginalName); //앞에 s 다 떼고 원본받게 하기 위함
		HttpHeaders headers = new HttpHeaders();
		log.info("http 헤더  : "+headers);
		try {
			String downloadName = null;
			if(userAgent.contains("Trident")) {
				log.info("익스");
				downloadName = URLEncoder.encode(resourceOriginalName,"UTF-8").replace("\\+", " ");
			}else if(userAgent.contains("Edge")) {
				log.info("엣지");
				downloadName = URLEncoder.encode(resourceOriginalName,"UTF-8");
				log.info("엣지 이름 : "+downloadName);
			}else {
				log.info("크롬 브라우더");
				downloadName = new String(resourceOriginalName.getBytes("UTF-8"),"ISO-8859-1");
			}
			log.info("다운로드 될 파일 이름  : "+downloadName);
			headers.add("Content-Disposition","attachment;filename="+ downloadName);
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return new ResponseEntity<Resource>(resource,headers,HttpStatus.OK);
		
	}
	@PostMapping("/deleteFile")
	@ResponseBody
	public ResponseEntity<String> deleteFile(String fileName, String type){
		log.info("삭제될 파일 : "+fileName);
		File file;
		
		try {
			file = new File("c:\\upload\\"+URLDecoder.decode(fileName, "UTF-8"));
			file.delete();
			if(type.equals("image")) {
				String largeFileName = file.getAbsolutePath().replace("s_", "");
				log.info("섬네일 말고 원본 : "+largeFileName);
				file = new File(largeFileName);
				file.delete();
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
			return new ResponseEntity<>(HttpStatus.NOT_FOUND);
		}
		return new ResponseEntity<>("deleted",HttpStatus.OK);
	}
}
