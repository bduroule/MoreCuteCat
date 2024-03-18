import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatChooserComponent } from './CatChooserComponent';

describe('CatChooserComponent', () => {
  let component: CatChooserComponent;
  let fixture: ComponentFixture<CatChooserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CatChooserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CatChooserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
