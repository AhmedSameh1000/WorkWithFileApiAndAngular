import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloudinaryImageComponent } from './cloudinary-image.component';

describe('CloudinaryImageComponent', () => {
  let component: CloudinaryImageComponent;
  let fixture: ComponentFixture<CloudinaryImageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CloudinaryImageComponent]
    });
    fixture = TestBed.createComponent(CloudinaryImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
