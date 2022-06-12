import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RestApiService } from 'src/shared/rest-api.service';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  products: IProduct[] = [];
  private _restApiService: RestApiService
  constructor(restApiService: RestApiService) {
    this._restApiService = restApiService;
  }

  ngOnInit(): void {
    this._restApiService.get<IProduct[]>('/api/products')
      .subscribe((val: IProduct[]) => {
        this.products = val;
      });
  }

  title = 'CloudsEcommerceClientApp';
}