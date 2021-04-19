import { Component, OnInit } from "@angular/core";
import { ITemparature } from "./temparature";
import { WeatherService } from "./weather.service";

@Component({
  selector: "app-fetch-data",
  templateUrl: "./converter.component.html",
  styleUrls: ["./converter.component.css"],
})
export class ConverterComponent implements OnInit {
  result: ITemparature;
  celcius: number = 100;  
  componentTitle = "Temparature Converter";
  errorMessage = "";

  constructor(private weatherService: WeatherService) {}

  ngOnInit(): void {
    this.getResults();
  }

  sendDetails(): void {
    this.getResults();
  }

  getResults() {
    this.weatherService.getResults(this.celcius).subscribe(
      (response) => {
        this.result = response;
      },
      (error) => {
        console.error(error);
        this.errorMessage =
          "Couldn't load results temporarily, please try again later.";
      }
    );
  }

}
