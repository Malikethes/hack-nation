<template>
  <v-app>
    <AppBar />
    <v-main>
      <v-container class="py-10">
        <v-row justify="center">
          <v-col cols="12" md="8" lg="6">
            <div class="mb-8">
              <p class="text-body-1 font-weight-medium mb-3">
                Step 1 of 5: Item Identification
              </p>
              <v-progress-linear
                :model-value="20"
                color="primary"
                height="8"
                rounded
              />
            </div>

            <v-card
              elevation="1"
              rounded="xl"
              class="pa-6 pa-sm-8"
            >
              <div class="mb-8">
                <h1 class="text-h4 text-sm-h3 font-weight-black mb-2">
                  Tell us about the found item.
                </h1>
                <p class="text-body-1 text-medium-emphasis">
                  This information will help us categorize and identify the item correctly.
                </p>
              </div>

              <v-form ref="form" v-model="valid">
                <v-select
                  v-model="formData.itemType"
                  :items="itemTypes"
                  label="What type of item is it?"
                  variant="outlined"
                  color="primary"
                  class="mb-4"
                  :rules="[rules.required]"
                  placeholder="Select item type"
                />

                <v-textarea
                  v-model="formData.description"
                  label="Provide a brief description"
                  variant="outlined"
                  color="primary"
                  rows="4"
                  class="mb-4"
                  :rules="[rules.required]"
                />

                <v-text-field
                  v-model="formData.uniqueIdentifiers"
                  variant="outlined"
                  color="primary"
                  placeholder="e.g., Serial number, name tag, specific scratches"
                  class="mb-4"
                >
                  <template #label>
                    <div class="d-flex align-center">
                      <span>List any unique identifiers (optional)</span>
                      <v-tooltip location="top">
                        <template #activator="{ props }">
                          <v-icon
                            v-bind="props"
                            size="small"
                            class="ml-2"
                          >
                            mdi-help-circle-outline
                          </v-icon>
                        </template>
                        <span>
                          Include details like serial numbers, engravings, name tags, or specific scratches that can uniquely identify the item.
                        </span>
                      </v-tooltip>
                    </div>
                  </template>
                </v-text-field>
              </v-form>

              <v-divider class="my-6" />
              <div class="d-flex justify-space-between align-center">
                <v-btn
                  variant="text"
                  color="medium-emphasis"
                  size="large"
                  @click="handleCancel"
                >
                  Cancel
                </v-btn>
                <v-btn
                  color="primary"
                  size="large"
                  :disabled="!valid"
                  @click="handleNext"
                >
                  Next: Add Location
                </v-btn>
              </div>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
const valid = ref(false)
const form = ref(null)

const formData = ref({
  itemType: '',
  description: '',
  uniqueIdentifiers: '',
})

const itemTypes = [
  { title: 'Wallet', value: 'wallet' },
  { title: 'Phone', value: 'phone' },
  { title: 'Keys', value: 'keys' },
  { title: 'Bag', value: 'bag' },
  { title: 'Other', value: 'other' },
]

const rules = {
  required: (value: string) => !!value || 'This field is required',
}

const handleCancel = () => {
  navigateTo('/dashboard')
}

const handleNext = () => {
  if (valid.value) {
    navigateTo('/step_two')
  }
}
</script>
