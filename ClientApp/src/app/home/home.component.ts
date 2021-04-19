import { Component } from "@angular/core";
import { WeatherService } from "../weather/weather.service";
import { IWeatherReport } from "../weather/weatherreport";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  weather: any;
  errorMessage = "";

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.weatherService.getWeather().subscribe(
      (response) => {
        this.weather = response;
      },
      (error) => {
        console.error(error);
        this.errorMessage =
          "Couldn't load results temporarily, please try again later.";
      }
    );
  }


}
