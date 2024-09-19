import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { SalesService } from '../../services/sales.service';
import { getCustomerOrders } from '../../models/getCustomerOrder';
import { salesDatePredictor } from '../../models/salesDatePredictor';
import { ModalComponent } from "../modal/modal.component";

declare var bootstrap: any;
@Component({
  selector: 'app-salesdatepredictorsgrid',
  standalone: true,
  imports: [CommonModule, ModalComponent],
  templateUrl: './salesdatepredictorsgrid.component.html',
  styleUrl: './salesdatepredictorsgrid.component.css'
})

export class SalesdatepredictorsgridComponent implements OnInit{
  constructor(public salesService: SalesService){}
  selectedItem: getCustomerOrders[] = [];
  openModal(id: number, name: string) {
    console.log(id);
    this.salesService.getCustomerOrders(id);
    this.salesService.customerName = name;
    const modalElement = document.getElementById('ordersModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  openNewModal(customer: salesDatePredictor){
    console.log(customer.id);
    this.salesService.customerName = customer.customerName;
    const modalElement = document.getElementById('newOrdModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  ngOnInit(): void {
    this.salesService.getSalesDatePredictor()
  }

  
}
