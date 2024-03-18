import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VoteCat } from '../componants/cat-chooser/model/voteCat.model';
import { Observable, catchError, tap } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class VoteCatService {

  constructor(private httpClient: HttpClient) { }

  voteForBestCat(voteCat: VoteCat): Observable<any> {
    return this.httpClient.post<any>(`${environment.apiURL}/Cats/vote`, voteCat).pipe(
      tap((response: any) => console.table(response)),
      catchError((error: any) => {
        console.log("test service", error);
        return [];
      })
    );
  }
}
