import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
const URL = 'https://evening-anchorage-3159.herokuapp.com/api/';

@Component({
  selector: 'app-cloudinary-image',
  templateUrl: './cloudinary-image.component.html',
  styleUrls: ['./cloudinary-image.component.css']
})

export class CloudinaryImageComponent implements OnInit {

  uploader!:FileUploader;
  hasBaseDropZoneOver=false;
  ngOnInit(): void {
 this.initialzieUplouder();
  }
 initialzieUplouder(){
  this.uploader=new FileUploader({
    url:"https://localhost:7268/api/PhotosCloudinary/UploadImg",
    isHTML5:true,
    allowedFileType:['image'],
    removeAfterUpload:true,
    autoUpload:false,
  });
  this.uploader.onAfterAddingFile=(file)=>{
    file.withCredentials=false;
  }
 }
}
