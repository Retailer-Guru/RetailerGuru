import { Component, Input, OnChanges, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ChartComponent } from 'ng-apexcharts';
import { Subscription } from 'rxjs';
import { ChartOptions } from 'src/app/models/chart-options';
import { DefaultStatModel } from 'src/app/models/default-stat-model';
import { ItemList } from 'src/app/models/item-list-model';
import { StatisticsModel } from 'src/app/models/statistics-model';
import { GlobalService } from 'src/clients/global_service';

@Component({
  selector: 'app-defaultbargraph',
  templateUrl: './defaultbargraph.component.html',
  styleUrls: ['./defaultbargraph.component.css']
})
export class DefaultbargraphComponent implements OnInit, OnChanges {

  @ViewChild("chart") chart!: ChartComponent;
  public chartOptions: Partial<ChartOptions> | any = {
    series: [
      {
        name: "Product Searches",
        data: []
      }
    ],
    chart: {
      height: 350,
      type: "bar"
    },
    title: {
      text: ""
    },
    xaxis: {
      categories: []
    }
  };

  @Input() productId : number = 0;

  constructor(private client : GlobalService) {
  }

  ngOnInit() {

    this.loadData();
  }

  ngOnChanges(){
    this.loadData();
  }


  private loadData(){
    if(this.productId === 0)
      return;

    let now = new Date();

    let model = new StatisticsModel();
    model.id = this.productId;
    model.from = new Date(now.getFullYear(), now.getMonth(), now.getDate() - 7);
    model.to = now;

    this.client.postObject('api/v1-spa/Statistics/GetDailyProductSearchStatistic', model)
      .subscribe(res => {
        let dataList : ItemList<DefaultStatModel> = (<any>res).result;
        let dataLine : number[] = dataList.items.map(x => x.count)
        let descriptionLine : string[] = dataList.items.map(x => x.date.toString());

        this.chartOptions.series = [{
          data: dataLine
        }];

        this.chartOptions.xaxis = {
          categories: descriptionLine
        }
      });
  }

}
