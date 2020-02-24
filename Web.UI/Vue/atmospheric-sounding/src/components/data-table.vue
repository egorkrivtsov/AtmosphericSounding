<template>
  <div>
    <q-table
      class="data-table"
      ref="table"
      :data="rows"
      :columns="columns"
      row-key="index"
      :virtual-scroll = "true"
      :pagination.sync="pagination"
      :rows-per-page-options="[0]"
    />

    <q-page-sticky position="bottom-right" :offset="btnScrollTopPosition">
      <q-btn-group rounded v-touch-pan.prevent.mouse="moveScrollTopButton">
        <q-btn glossy rounded  color="primary" label="В начало" @click="scrollTo('start')"/>
        <q-btn glossy rounded  color="primary" label="В конец" @click="scrollTo('end')"/>
        <!-- <q-btn glossy rounded  color="primary" label="update" /> -->
      </q-btn-group>
            <!-- <q-btn fab
              color="primary"
              @click="scrollTo('start')"
              icon="keyboard_arrow_up"
              :disable="btnScrollTopDraggable"
              v-touch-pan.prevent.mouse="moveScrollTopButton" >
            </q-btn> -->
            <!-- <div class="q-pa-md" style="width:250px;" v-touch-pan.prevent.mouse="moveScrollTopButton">
              <q-slider
                v-model="intervalValue"
                :min="2"
                :max="20"
                label
                :label-value="'Интервал: ' + intervalValue + ' сек'"
                label-always
                color="primary"
              />
            </div> -->
    </q-page-sticky>
  </div>
</template>
<script lang="ts">

import Vue from 'vue'
import Component from 'vue-class-component'
// import { Watch } from 'vue-property-decorator'
import { QTable, QPageSticky, QBtn, QFab, TouchPan, QBtnGroup, QSlider } from 'quasar'
import store, { dataStore, DataModuleName } from '@/store'
import { nameOfFunction } from '@/common/helpers'

@Component({
  name: 'DataTable',
  components: { QTable, QPageSticky, QBtn, QFab, QBtnGroup, QSlider },
  directives: {
    TouchPan
  }
})
export default class DataTable extends Vue {
  public get rows (): any[] { return dataStore.rows }

  public get columns (): any[] { return dataStore.columns }

  public btnScrollTopPosition : number[] = [ 18, 18 ];

  public btnScrollTopDraggable : boolean = false;

  public pagination: any = { rowsPerPage: 0 };

  public intervalValue: number = 2;

  $refs!: {
    table: QTable
  }

  // @Watch('rows')
  // public onChildChanged (newValue: any, oldValue: any) { this.scrollTo('end') }

  public async mounted () {
    await dataStore.loadAll()
    store.subscribe((mutation: any, state: any) => {
      if (mutation.type === `${DataModuleName}/${nameOfFunction(dataStore, dataStore.addRow)}`) {
        // this.scrollTo('end')
      }
    })
  }

  public scrollTo (position: 'start' | 'end' | number) {
    switch (position) {
      case 'start' :
        this.$refs.table.scrollTo(0)
        break
      case 'end' :
        this.$refs.table.scrollTo(this.rows.length)
        break
      default :
        this.$refs.table.scrollTo(position)
        break
    }
  }

  public moveScrollTopButton (event : any) {
    this.btnScrollTopDraggable = event.isFirst !== true && !event.isFinal

    this.btnScrollTopPosition = [
      this.btnScrollTopPosition[0] - event.delta.x,
      this.btnScrollTopPosition[1] - event.delta.y
    ]
  }
}

</script>

<style lang="scss">
$height-val: 700px;

.data-table {
  /* height or max-height is important */
  // height: $height-val;
  .q-virtual-scroll {
    max-height: $height-val;
  }
  .q-table__top,
  .q-table__bottom,
  thead tr:first-child th /* bg color is important for th; just specify one */
  {
    background-color: #fff;
  }

  thead tr th {
    position: sticky;
    z-index: 1;
  }
  /* this will be the loading indicator */
  thead tr:last-child th {
    /* height of all previous header rows */
    top: 48px;
  }
  thead tr:first-child th {
    top: 0;
  }
}
</style>
