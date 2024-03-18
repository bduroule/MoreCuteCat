import { Component, Input } from '@angular/core';
import { CatService } from '../../../services/cat.service';
import { Cat } from '../model/cat.model';

@Component({
  standalone: true,
  selector: 'app-grid-cat-detail',
  templateUrl: './grid-cat-detail.component.html',
  styleUrl: './grid-cat-detail.component.scss'
})
export class GridCatDetailComponent {
  @Input() cat: Cat;
}
