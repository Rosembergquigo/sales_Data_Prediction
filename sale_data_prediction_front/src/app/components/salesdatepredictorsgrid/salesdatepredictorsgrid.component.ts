import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { SalesService } from '../../services/sales.service';
import { getCustomerOrders } from '../../models/getCustomerOrder';

declare var bootstrap: any;
@Component({
  selector: 'app-salesdatepredictorsgrid',
  standalone: true,
  imports: [ CommonModule],
  templateUrl: './salesdatepredictorsgrid.component.html',
  styleUrl: './salesdatepredictorsgrid.component.css'
})

export class SalesdatepredictorsgridComponent implements OnInit{
  constructor(public salesService: SalesService){}
  selectedItem: getCustomerOrders[] = [];
  openModal(id: number, name: string) {
    this.salesService.getCustomerOrders(id);
    this.salesService.customerName = name;
    const modalElement = document.getElementById('myModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }
  ngOnInit(): void {
    this.salesService.getSalesDatePredictor()
  }

  
}
