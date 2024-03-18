import { Component, Input } from '@angular/core';
import { Cat } from '../../grid-cat/model/cat.model';

@Component({
  selector: 'app-cat-choice',
  standalone: true,
  imports: [],
  templateUrl: './cat-choice.component.html',
  styleUrl: './cat-choice.component.scss'
})
export class CatChoiceComponent {
  @Input() cat: Cat;
}
