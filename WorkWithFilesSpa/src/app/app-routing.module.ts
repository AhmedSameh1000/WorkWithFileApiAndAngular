import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CloudinaryImageComponent } from './cloudinary-image/cloudinary-image.component';

const routes: Routes = [
  {path:"cloudinary",component:CloudinaryImageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
