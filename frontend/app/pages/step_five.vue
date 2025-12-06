<template>
  <v-app>
    <v-main>
      <v-container class="py-5">
        <v-row justify="center">
          <v-col cols="12" lg="10" xl="8">
            <!-- Header Card -->
    <AppBar>
    </AppBar>

            <!-- Progress Section -->
            <div class="mb-8 px-4">
              <p class="text-body-1 font-weight-medium mb-3">
                Step 5 of 5: Summary
              </p>
              <v-progress-linear
                :model-value="100"
                color="primary"
                height="8"
                rounded
              />
            </div>

            <!-- Page Header -->
            <div class="px-4 mb-8">
              <h1 class="text-h3 text-md-h2 font-weight-black">
                Summary of All Information
              </h1>
            </div>

            <!-- Item Details Section -->
            <v-card elevation="1" rounded="lg" class="mb-6">
              <v-card-title class="text-h6 font-weight-bold pa-6">
                Item Details
              </v-card-title>
              <v-card-text class="pa-6 pt-0">
                <v-divider class="mb-4" />
                
                <div class="summary-row">
                  <span class="summary-label">Category / Item Type</span>
                  <span class="summary-value">{{ itemData.category }}</span>
                </div>
                <v-divider />
                
                <div class="summary-row">
                  <span class="summary-label">Detailed Description</span>
                  <span class="summary-value">{{ itemData.description }}</span>
                </div>
                <v-divider />
                
                <div class="summary-row">
                  <span class="summary-label">Photos</span>
                  <div class="d-flex gap-4">
                    <v-img
                      v-for="(photo, index) in itemData.photos"
                      :key="index"
                      :src="photo"
                      width="96"
                      height="96"
                      cover
                      rounded="lg"
                    />
                  </div>
                </div>
              </v-card-text>
            </v-card>

            <!-- Place and Time Section -->
            <v-card elevation="1" rounded="lg" class="mb-6">
              <v-card-title class="text-h6 font-weight-bold pa-6">
                Place and Time of Finding
              </v-card-title>
              <v-card-text class="pa-6 pt-0">
                <v-row>
                  <v-col cols="12" md="6">
                    <div class="mb-5">
                      <div class="d-flex mb-2">
                        <span class="location-label">Location</span>
                      </div>
                      <span class="location-value">{{ locationData.address }}</span>
                    </div>
                    <div class="mb-5">
                      <div class="d-flex mb-2">
                        <span class="location-label">Date of finding</span>
                      </div>
                      <span class="location-value">{{ locationData.date }}</span>
                    </div>
                    <div class="mb-5">
                      <div class="d-flex mb-2">
                        <span class="location-label">Time of finding</span>
                      </div>
                      <span class="location-value">{{ locationData.time }}</span>
                    </div>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-card elevation="0" rounded="lg" class="overflow-hidden" height="250">
                      <v-img
                        src="https://lh3.googleusercontent.com/aida-public/AB6AXuAY574PyvwW_vqNGAijaKTUlhov6b33stomHgh_A-xVaPYLJpqmg1D1Wkp54easDLiCK8vQGLLu9QCgS4eHhJKWDTDT1TxI0rDkGDboVo02v5XXV_K_x79K2NGTQ3pmIP2Sb1Vlp4vX9ywJjNNS57tM4HjAVqxL1n8scZOwCAmxh4IUpMMSG-Ndoh9NYka6L3SanrFg-WihVnnyaGuH9YRXKja6XsIvzGgfyNDbW-6k4062NDgD_UL1kRkwViHRFNSkzLSPtpt5xEA"
                        alt="Map indicating the location"
                        cover
                        height="100%"
                      />
                    </v-card>
                  </v-col>
                </v-row>
              </v-card-text>
            </v-card>

            <!-- Finder's Details Section -->
            <v-card elevation="1" rounded="lg" class="mb-6">
              <v-card-title class="text-h6 font-weight-bold pa-6">
                Finder's Details
              </v-card-title>
              <v-card-text class="pa-6 pt-0">
                <v-divider class="mb-4" />
                
                <div class="summary-row">
                  <span class="summary-label">Full Name</span>
                  <span class="summary-value">{{ finderData.fullName }}</span>
                </div>
                <v-divider />
                
                <div class="summary-row">
                  <span class="summary-label">Phone Number</span>
                  <span class="summary-value">{{ finderData.phone }}</span>
                </div>
                <v-divider />
                
                <div class="summary-row">
                  <span class="summary-label">Email Address</span>
                  <span class="summary-value">{{ finderData.email }}</span>
                </div>
              </v-card-text>
            </v-card>

            <!-- Action Buttons -->
            <div class="d-flex flex-column flex-sm-row align-center justify-space-between gap-4 pa-4">
              <v-btn
                color="primary"
                size="x-large"
                prepend-icon="mdi-check-circle"
                @click="handleConfirm"
              >
                Confirm and Report
              </v-btn>
              <div class="d-flex align-center gap-6">
                <v-btn
                  variant="text"
                  color="primary"
                  prepend-icon="mdi-pencil"
                  @click="handleEdit"
                >
                  Edit Data
                </v-btn>
                <v-btn
                  variant="text"
                  color="medium-emphasis"
                  prepend-icon="mdi-close"
                  @click="handleCancel"
                >
                  Cancel
                </v-btn>
              </div>
            </div>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
const breadcrumbs = [
  { title: 'Home', disabled: false, href: '/' },
  { title: 'Add a finding', disabled: false, href: '#' },
  { title: 'Summary', disabled: true },
]

// Sample data - in real app, this would come from a store/composable
const itemData = ref({
  category: 'Electronics',
  description: 'Black smartphone of brand X, found near the city park. The screen is cracked in the upper left corner.',
  photos: [
    'https://lh3.googleusercontent.com/aida-public/AB6AXuCUJjgnObaBW7ltI_K4CL-UoFzQzBaQHhLyNLOXXbmhN1yV8GsAHCA9gVIwg_9gksqIDm5ijdWfVwP5vrhvmElJP7fGdT5vMYN-RijBdf_JLNdZZMe63QRMKEG62tZzOjUo7QrOaAYxFfx6knzRfKnEgKT5snnXiZO9LWBK0tyNovUARI_sSphUB3Ik9MtcYAba5FcvIyBYbiOkurGSlIAMgZ2ZIUDCX80Dr_i5KtIdcsXNYvnVpD60UPdMFom0qluiqDELmq3T5j8',
    'https://lh3.googleusercontent.com/aida-public/AB6AXuDuIZ8MVAm46TzGVbi8WvWOZVhr-_vHXf2Sr927PPYGRyFUIHRFjvs6YH0FtLOpK5d9jIF7J5pdSn3jg4BClpytrsJgqk8goL1G3fJeg7oU1SdNeNGuhfTKUy6C8xR8p3ft8tEel-52CesrDBg_f25CXTFL1BQOdQMjv9u9uhwnYE5sS56l7zthzll_K4zzB32H68h3Y_DeGFzXJN7y33k3v7rM69UV2Z2l6MruosiIxSUWFS4L-NjspR7G9u1gqlDNErApjPOK-g0',
  ],
})

const locationData = ref({
  address: '1 Marszałkowska St, 00-001 Warsaw',
  date: 'October 15, 2023',
  time: 'approx. 2:30 PM',
})

const finderData = ref({
  fullName: 'John Smith',
  phone: '+48 123 456 789',
  email: 'john.smith@email.com',
})

const handleConfirm = () => {
  console.log('Confirming and submitting report...')
  // Submit the report
  // navigateTo('/confirmation')
}

const handleEdit = () => {
  console.log('Edit data')
  navigateTo('/step_one')
}

const handleCancel = () => {
  navigateTo('/dashboard')
}
</script>

<style scoped>
.logo-icon {
  color: rgb(var(--v-theme-primary));
  display: flex;
  align-items: center;
  justify-content: center;
}

.summary-row {
  display: grid;
  grid-template-columns: 200px 1fr;
  gap: 1.5rem;
  padding: 1.25rem 0;
  align-items: start;
}

@media (max-width: 960px) {
  .summary-row {
    grid-template-columns: 1fr;
    gap: 0.5rem;
  }
}

.summary-label {
  font-size: 0.875rem;
  opacity: 0.7;
}

.summary-value {
  font-size: 0.875rem;
  font-weight: 500;
}

.location-label {
  font-size: 0.875rem;
  opacity: 0.7;
  min-width: 120px;
}

.location-value {
  font-size: 0.875rem;
  font-weight: 500;
}
</style>