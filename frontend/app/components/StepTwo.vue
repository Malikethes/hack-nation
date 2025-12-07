<template>
  <v-form ref="form" @update:model-value="$emit('update:valid', $event)">
    <div class="mb-10">
      <h3 class="text-h6 font-weight-bold mb-4 pb-3 border-b">Address</h3>
      <v-row>
        <v-col cols="12" md="6">
          <v-select
            :model-value="formData.province"
            @update:model-value="formData.province = $event"
            :items="provinces"
            label="Province"
            variant="outlined"
            color="primary"
            placeholder="Select province"
            :rules="[rules.required]"
          />
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.city"
            @update:model-value="formData.city = $event"
            label="City/Town"
            variant="outlined"
            color="primary"
            placeholder="E.g., Warsaw"
            :rules="[rules.required]"
          />
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.street"
            @update:model-value="formData.street = $event"
            label="Street and number"
            variant="outlined"
            color="primary"
            placeholder="E.g., Aleje Jerozolimskie 97"
            :rules="[rules.required]"
          />
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.postalCode"
            @update:model-value="formData.postalCode = $event"
            label="Postal code"
            variant="outlined"
            color="primary"
            density="comfortable"
            placeholder="E.g., 00-001"
            :rules="[rules.required]"
          />
        </v-col>
      </v-row>
    </div>

    <div class="mb-10">
      <h3 class="text-h6 font-weight-bold mb-4 pb-3 border-b">Date and Time</h3>
      <v-row>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.dateDiscovery"
            @update:model-value="formData.dateDiscovery = $event"
            type="date"
            label="Date of discovery"
            variant="outlined"
            color="primary"
            prepend-inner-icon="mdi-calendar"
            :rules="[rules.required]"
          />
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.timeDiscovery"
            @update:model-value="formData.timeDiscovery = $event"
            type="time"
            label="Approximate time of discovery"
            variant="outlined"
            color="primary"
            prepend-inner-icon="mdi-clock-outline"
          />
        </v-col>
      </v-row>
    </div>

    <div class="mb-6">
      <h3 class="text-h6 font-weight-bold mb-4 pb-3 border-b">Location on Map</h3>
      <v-row>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.latitude"
            @update:model-value="formData.latitude = $event"
            label="Latitude"
            variant="outlined"
            color="primary"
            placeholder="E.g., 52.2297"
            :rules="[rules.required]"
          />
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field
            :model-value="formData.longitude"
            @update:model-value="formData.longitude = $event"
            label="Longitude"
            variant="outlined"
            color="primary"
            placeholder="E.g., 21.0122"
            :rules="[rules.required]"
          />
        </v-col>
        <v-col cols="12">
          <v-card elevation="0" rounded="lg" class="overflow-hidden mb-4">
            <iframe
              :src="mapUrl"
              width="100%"
              height="400"
              style="border:0;"
              allowfullscreen
              loading="lazy"
              referrerpolicy="no-referrer-when-downgrade"
            ></iframe>
          </v-card>
          <v-btn
            color="primary"
            variant="tonal"
            prepend-icon="mdi-map-marker"
            @click="openMapLink"
            block
          >
            View on Google Maps
          </v-btn>
        </v-col>
      </v-row>
    </div>
  </v-form>
</template>

<script setup lang="ts">
const props = defineProps<{
  formData: any
  provinces: string[]
  rules: any
  valid: boolean
}>()

defineEmits(['update:valid'])

const form = ref(null)

const mapUrl = computed(() => {
  const lat = props.formData.latitude || '52.2297'
  const lng = props.formData.longitude || '21.0122'
  return `https://www.google.com/maps/embed/v1/place?key=AIzaSyBFw0Qbyq9zTFTd-tUY6dZWTgaQzuU17R8&q=${lat},${lng}&zoom=15`
})

const openMapLink = () => {
  const lat = props.formData.latitude || '52.2297'
  const lng = props.formData.longitude || '21.0122'
  window.open(`https://www.google.com/maps?q=${lat},${lng}`, '_blank')
}
</script>

<style scoped>
.border-b {
  border-bottom: 1px solid rgb(var(--v-theme-on-surface), 0.12);
}
</style>
