import { Component, OnInit } from '@angular/core';
import { GridCatDetailComponent } from './grid-cat-detail/grid-cat-detail.component';
import { CatService } from '../../services/cat.service';
import { Cat } from './model/cat.model';
import { Observable } from 'rxjs';
import {CommonModule} from '@angular/common';

@Component({
    selector: 'app-grid-cat',
    standalone: true,
    imports: [GridCatDetailComponent, CommonModule],
    templateUrl: './grid-cat.component.html',
    styleUrl: './grid-cat.component.scss'
})
export class GridCatComponent implements OnInit {

  catsObservable: Observable<Cat[]> = this.catService.getAllCats();

  cats: Cat[] = [];

  constructor(private catService: CatService) {}

  ngOnInit(): void {
    this.catsObservable.subscribe({
      next: (cats: Cat[]) => {
        cats.sort((a: any, b: any) => b.score - a.score);
        this.cats = cats;
      },
      error: (error: any) => {
        console.error('an Eroor ocurade');
      }
    });
    console.table(this.cats)
  }
}
