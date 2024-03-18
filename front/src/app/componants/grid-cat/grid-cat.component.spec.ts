import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridCatComponent } from './grid-cat.component';

describe('GridCatComponent', () => {
  let component: GridCatComponent;
  let fixture: ComponentFixture<GridCatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GridCatComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GridCatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
