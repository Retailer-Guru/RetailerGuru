import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartComponent } from 'ng-apexcharts/lib/chart/chart.component';
import { ChartOptions } from 'src/app/models/chart-options';

@Component({
  selector: 'app-statistikview',
  templateUrl: './statistikview.component.html',
  styleUrls: ['./statistikview.component.css']
})
export class StatistikviewComponent implements OnInit {

  @ViewChild("chart") chart!: ChartComponent;
  public chartOptions: Partial<ChartOptions> | any;

  constructor()
  {
    this.chartOptions = {
      series: [
        {
          name: "My-series",
          data: [10, 41, 35, 51, 49, 62, 69, 91, 148]
        }
      ],
      chart: {
        height: 350,
        type: "bar"
      },
      title: {
        text: "My First Angular Chart"
      },
      xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept"]
      }
    };
  }

  ngOnInit() {
  }

}
