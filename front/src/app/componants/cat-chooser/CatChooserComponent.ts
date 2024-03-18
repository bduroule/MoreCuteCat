import { Component } from '@angular/core';
import { CatChoiceComponent } from './cat-choice/cat-choice.component';
import { Observable } from 'rxjs';
import { CatService } from '../../services/cat.service';
import { Cat } from '../grid-cat/model/cat.model';
import { CommonModule } from '@angular/common';
import { VoteCatService } from '../../services/vote-cat.service';
import { VoteCat } from './model/voteCat.model';


@Component({
  selector: 'app-cat-chooser',
  standalone: true,
  imports: [CatChoiceComponent, CommonModule],
  templateUrl: './cat-chooser.component.html',
  styleUrl: './cat-chooser.component.scss'
})
export class CatChooserComponent {
  catsObservable: Observable<Cat[]>;

  cats: Cat[] = [];

  constructor(private catService: CatService, private voteCatService: VoteCatService) { }

  ngOnInit(): void {
    this.loadCats(2, []);
  }

  loadCats(numberOfCatToLoad: number, excludeIds: string[]) {
    this.catsObservable = this.catService.getRendomCats(2, []);
    this.catsObservable.subscribe({
      next: (cats: Cat[]) => {
        this.cats = cats;
      },
      error: (error: any) => {
        console.error('an Eroor ocurade');
      }
    });
    console.table(this.cats);
  }

  pushCatVoted(cat: Cat) {
    let participatingCats = this.cats;
    let winnerCatId = cat.id;
    let looserCat: any;

    let winnerCatIndex: number = participatingCats.findIndex(cat => cat.id === winnerCatId);

    console.log("COUOUOUOUOUOUOUOUOUOUO", winnerCatIndex)
    if (winnerCatIndex !== -1) {
      looserCat = participatingCats.splice(winnerCatIndex, 1)[0];
    }
    
    let voteCat: VoteCat = new VoteCat(looserCat, winnerCatId);
    this.voteCatService.voteForBestCat(voteCat).subscribe({
      next: (response: any) => {
        console.log('Vote successful:', response);
      },
      error: (error: any) => {
        console.error('Error while voting:', error);
      }
    });
    this.loadCats(2, []);
  }
}