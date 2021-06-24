import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RateMapComponent } from './rate-map.component';

describe('RateMapComponent', () => {
  let component: RateMapComponent;
  let fixture: ComponentFixture<RateMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RateMapComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RateMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
