<template>
  <v-app>
    <AppBar>
    </AppBar>

    <v-main>
      <v-container class="py-5 py-lg-10">
        <v-row justify="center">
          <v-col cols="12" md="10" lg="8">
            <!-- Progress Section -->
            <div class="mb-8">
              <p class="text-body-1 font-weight-medium mb-3">
                Step 4 of 5: Finder's Contact Details
              </p>
              <v-progress-linear
                :model-value="80"
                color="primary"
                height="8"
                rounded
              />
            </div>

            <!-- Page Header -->
            <div class="mb-8">
              <h1 class="text-h3 text-md-h2 font-weight-black mb-3">
                Step 4: Contact & Storage Info
              </h1>
              <p class="text-body-1 text-medium-emphasis">
                Provide details for the person who found the item to get in touch and arrange pickup.
              </p>
            </div>

            <!-- Contact & Pickup Information Card -->
            <v-card elevation="0" variant="outlined" class="mb-6">
              <v-card-title class="text-h6 font-weight-bold pa-6">
                Contact & Pickup Information
              </v-card-title>
              <v-card-text class="pa-6 pt-0">
                <v-form ref="form" v-model="valid">
                  <!-- Contact Person/Department -->
                  <v-text-field
                    v-model="formData.contactPerson"
                    label="Contact Person / Department"
                    variant="outlined"
                    color="primary"
                    placeholder="Enter the name of the contact person or department"
                    class="mb-4"
                    :rules="[rules.required]"
                  />

                  <!-- Contact Phone and Email -->
                  <v-row class="mb-4">
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="formData.contactPhone"
                        label="Contact Phone"
                        variant="outlined"
                        color="primary"
                        placeholder="Enter phone number"
                        :rules="[rules.required, rules.phone]"
                      />
                    </v-col>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="formData.contactEmail"
                        label="Contact Email"
                        variant="outlined"
                        color="primary"
                        placeholder="Enter email address"
                        type="email"
                        :rules="[rules.required, rules.email]"
                      />
                    </v-col>
                  </v-row>

                  <!-- Storage Location/Pickup Address -->
                  <v-textarea
                    v-model="formData.storageAddress"
                    label="Storage Location / Pickup Address"
                    variant="outlined"
                    color="primary"
                    placeholder="Enter the full address where the item is stored"
                    rows="3"
                    :rules="[rules.required]"
                  />
                </v-form>
              </v-card-text>
            </v-card>

            <!-- Action Buttons -->
            <div class="d-flex justify-space-between align-center">
              <v-btn
                variant="text"
                size="large"
                @click="handleBack"
              >
                Back
              </v-btn>
              <v-btn
                color="primary"
                size="large"
                :disabled="!valid"
                @click="handleNext"
              >
                Next
              </v-btn>
            </div>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
const valid = ref(false)
const form = ref(null)

const breadcrumbs = [
  { title: 'gov.pl', disabled: false, href: '/' },
  { title: 'Services', disabled: false, href: '#' },
  { title: 'Found Items', disabled: false, href: '#' },
  { title: 'New Report', disabled: true },
]

const formData = ref({
  contactPerson: '',
  contactPhone: '',
  contactEmail: '',
  storageAddress: '',
})

const rules = {
  required: (value: string) => !!value || 'This field is required',
  email: (value: string) => {
    const pattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
    return pattern.test(value) || 'Invalid email address'
  },
  phone: (value: string) => {
    const pattern = /^[+]?[\d\s()-]+$/
    return pattern.test(value) || 'Invalid phone number'
  },
}

const handleBack = () => {
  navigateTo('/step_three')
}

const handleNext = () => {
  if (valid.value) {
    console.log('Form data:', formData.value)
    // Navigate to step 5
    // navigateTo('/step_five')
  }
}
</script>
