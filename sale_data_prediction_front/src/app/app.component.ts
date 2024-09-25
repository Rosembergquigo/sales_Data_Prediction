import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { SalesdatepredictorsgridComponent } from "./components/salesdatepredictorsgrid/salesdatepredictorsgrid.component";
import { HeaderComponent } from "./components/header/header.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
    SalesdatepredictorsgridComponent, 
    HeaderComponent

  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'sale_data_prediction_front';
}
