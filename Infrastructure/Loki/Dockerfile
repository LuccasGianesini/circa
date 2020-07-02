FROM grafana/loki:latest 

COPY loki.yaml /etc/loki/

ENTRYPOINT [ "/usr/bin/loki", "-config.file=/etc/loki/loki.yaml" ]