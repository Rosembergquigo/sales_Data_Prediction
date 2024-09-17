import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { salesDatePredictor } from '../models/salesDatePredictor';
import { getCustomerOrders } from '../models/getCustomerOrder';

@Injectable({
  providedIn: 'root'
})
export class SalesService {
  myApiUrl = "https://localhost:44376/api/";
  
  list: salesDatePredictor[] = [];
  ordersCust : getCustomerOrders[] = [];
  customerName: string = "";
  constructor( private http: HttpClient) { }

  getSalesDatePredictor(){
    this.http.get(this.myApiUrl + "order").toPromise()
    .then(data =>{
      this.list = data as salesDatePredictor[];
    })
  }
    getCustomerOrders(id: number){
      this.http.get(this.myApiUrl + "customer/order/" + id).toPromise()
      .then(data => {
        this.ordersCust = data as getCustomerOrders[];
      })
  }

}
