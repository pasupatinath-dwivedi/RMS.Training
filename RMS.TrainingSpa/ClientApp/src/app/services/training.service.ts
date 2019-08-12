import { Injectable } from "@angular/core";
import { TrainingModel, Response } from "../model/model";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  })
};

@Injectable()
export class TrainingService {
  base_url: string;
 
  //private handleError: HandleError;
  constructor(private httpClientService: HttpClient) {

    this.base_url = 'http://localhost:5000/';
  }

  ngOnInit() {
  }

  newTraining(training: TrainingModel): Observable<Response> {

   // return this.httpClientService.get<TrainingModel>(this.base_url+'api/Training');

    return this.httpClientService.post<Response>('http://localhost:5000/new', training, httpOptions);
     
  }

  ngOnDestroy(): void {
  }
}
