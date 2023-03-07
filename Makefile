name: Deploy UPM Force

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]

jobs:
  deploy-force:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@main
      - name: Push UPM Subtree
        run: |
          git fetch -f
          git checkout main -f
          git pull origin main -f
          git push origin --delete upm
          git subtree push --prefix Assets/ReTween origin upm
