import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatChoiceComponent } from './cat-choice.component';

describe('CatChoiceComponent', () => {
  let component: CatChoiceComponent;
  let fixture: ComponentFixture<CatChoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CatChoiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CatChoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
