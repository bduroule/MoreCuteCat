import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridCatDetailComponent } from './grid-cat-detail.component';

describe('GridCatDetailComponent', () => {
  let component: GridCatDetailComponent;
  let fixture: ComponentFixture<GridCatDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GridCatDetailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GridCatDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
