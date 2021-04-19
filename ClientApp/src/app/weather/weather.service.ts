import { element } from "protractor";
import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, tap, map } from "rxjs/operators";

import { ITemparature } from "./temparature";
import { IWeatherReport } from "./weatherreport";

@Injectable({
  providedIn: "root",
})
export class WeatherService {
  // If using Stackblitz, replace the url with this line
  // because Stackblitz can't find the api folder.
  private ConverterApiUrl = "";
  private WeatherApiUrl = "";


  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.ConverterApiUrl = baseUrl + "api/converter?celsius=";
    this.WeatherApiUrl = baseUrl + "api/Weather?city=Melbourne&country=Australia";
  }

  getResults(celcius): Observable<ITemparature> {
    return this.http.get<ITemparature>(this.ConverterApiUrl + celcius).pipe(
      tap((data) => console.log("Results: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getWeather(): Observable<any> {
    return this.http.get<any>(this.WeatherApiUrl).pipe(
      tap((data) => console.log("Results: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = "";
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
