import { Injectable } from '@angular/core';
import { Cat } from '../componants/grid-cat/model/cat.model';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CatService {

  constructor(private httpClient: HttpClient) { }

  getAllCats(): Observable<Cat[]> {

    return this.httpClient.get<Cat[]>(`${environment.apiURL}/Cats`).pipe(
      tap((response: any) => console.table(response)),
      catchError((error: any) => {
        console.log("test service", error);
        return [];
      })
    )
  }

  getRendomCats(count: number, ids: string[]): Observable<Cat[]> {
    
    const params = {
      count: count.toString(),
      ids: ids.join(',')
    };

    return this.httpClient.get<Cat[]>(`${environment.apiURL}/Cats/getRandomCats`, {params}).pipe(
      tap((response: any) => console.table(response)),
      catchError((error: any) => {
        console.log("test service", error);
        return [];
      })
    )
  }

}
