import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesdatepredictorsgridComponent } from './salesdatepredictorsgrid.component';

describe('SalesdatepredictorsgridComponent', () => {
  let component: SalesdatepredictorsgridComponent;
  let fixture: ComponentFixture<SalesdatepredictorsgridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesdatepredictorsgridComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalesdatepredictorsgridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
