import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

    constructor(http: HttpClient) {
        http.get<WeatherForecast[]>(environment.apiBaseUrl).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
     
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
