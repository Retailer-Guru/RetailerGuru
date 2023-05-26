/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DailyproductsearchComponent } from './dailyproductsearch.component';

describe('DailyproductsearchComponent', () => {
  let component: DailyproductsearchComponent;
  let fixture: ComponentFixture<DailyproductsearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailyproductsearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyproductsearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
