<template>
  <q-layout view="lHh Lpr lFf">
    <Header />
    <q-page-container>
      <Tabs />
    </q-page-container>
  </q-layout>
</template>

<script>
import { QLayout, QPageContainer } from 'quasar'

export default {
  name: 'LayoutDefault',
  components: {
    // sync loading
    // Tabs,
    // Header,
    /* Async loading componentn example */
    Tabs: () => import('@/components/tabs'),
    Header: () => import('@/components/header'),
    QLayout,
    QPageContainer
  }
}
</script>
